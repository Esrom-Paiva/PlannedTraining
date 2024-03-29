﻿using Microsoft.AspNetCore.Mvc;
using PlannedTraining.Server.Interfaces;
using PlannedTraining.Shared.Models;

namespace PlannedTraining.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public IEnumerable<Aluno> Get()
        {
            return _alunoService.GetAlunos();
        }

        [HttpGet("{id}")]
        public Aluno Get(long id)
        {
            return _alunoService.GetAluno(id);
        }

        [HttpGet("reativar")]
        public IEnumerable<Aluno> GetAlunosInativados()
        {
            return _alunoService.GetAlunosInativados();
        }


        [HttpPost("reativar/{id}")]
        public void ReativarAluno(long id)
        {
            _alunoService.ReativarAluno(id);
        }

        [HttpPost]
        public void Post(Aluno aluno) 
        {
            _alunoService.AddAluno(aluno);
        }

        [HttpPut]
        public void Put(Aluno aluno)
        {
            _alunoService.UpdateAluno(aluno);
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _alunoService.DeleteAluno(id);
        }
    }
}
