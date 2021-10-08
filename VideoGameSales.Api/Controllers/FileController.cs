using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoGameSales.Core.File.Command;
using VideoGameSales.Core.Games.Command;
using VideoGameSales.Domain.Errors;
using VideoGameSales.Domain.ViewModels.Games;
using VideoGameSales.Domain.ViewModels.IsValid;
using VideoGameSales.Util.Helpers;

namespace VideoGameSales.Api.Controllers
{
    [ApiController]
    [Authorize( AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FileController : ControllerBase
    {
        private const string _base = "api/File";
        private readonly IMediator _mediator;
        private readonly UrlHelpers _urlHelper;

        public FileController(IMediator mediator, UrlHelpers urlHelpers)
        {
            _mediator = mediator;
            _urlHelper = urlHelpers;
        }

        [HttpPost(_base)]
        public async Task<IActionResult> uploadFile([FromForm] FileUploadCommand upload)
        {

           
            List<IsValid<GameViewModel>> games = new List<IsValid<GameViewModel>>();
            using (var ms = new MemoryStream())
            {
                upload.file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                string str = System.Text.Encoding.UTF8.GetString(fileBytes, 0, fileBytes.Length);
                List<string> list = new List<string>(); 
                list = str.Split("\n").ToList();
                list.Remove(list.Last());

                foreach (var obj in list)
                {
                    var param = obj.Split(',');
                    if (param[0].ToLower() == "game")
                    {
                        games.Append(await createGame(obj));
                    }    
                }

                foreach (var game in games)
                {
                    
                    if (!game.Valid.IsValid)
                    {
                        return BadRequest(erroResponse(game.Valid));
                    }
                }
                return Ok(games.Select(x=> x.Data));
            }

        }


    private async Task<IsValid<GameViewModel>> createGame(string file)
    {

        List<int> platform = new List<int>();
        string noPlatformList = "";
        
        int start = file.IndexOf("[");
        int end = file.IndexOf("]");
            
        for (int i = start + 1; i <= end - 1; i++ )
        {
            if (file[i] != ',')
            {
                platform.Add((int)Char.GetNumericValue(file[i]));
            }
        }
        noPlatformList = file.Remove(start - 1, end-start+2);
        

        var game = noPlatformList.Split(",");
        var games = new CreateGameCommand
        {
            Ranks = Convert.ToInt32(game[1]),
            Name = game[2],
            Genre = game[3],
            Release_year = Convert.ToInt32(game[4]),
            Platform_Id = platform,
            Publisher_id = Convert.ToInt32(game[game.Count() - 1])
        };


        var command = await _mediator.Send(games);
        return command;
    }

    private ErrorResponse erroResponse(ValidationResult erros)
    {
        var Errors = new ErrorResponse();
            foreach (var erro in erros.Errors)
            {
                Errors.ErrorMessage.Add(new ErrorModel
                {
                    FieldName = erro.PropertyName,
                    ErrorMessage = erro.ErrorMessage
                });
            }
            return Errors;
        }
    }
}
