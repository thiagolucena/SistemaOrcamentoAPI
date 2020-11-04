using Application.Interfaces;
using ApplicationDTO.DTO;
using AutoMapper;
using Domain.Interfaces.IServices;
using Domain.Models;
using Security.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class UsuarioServiceApplication : IUsuarioServiceApplication
    {
        private readonly IMapper _mapper;

        public IUsuarioService _usuarioService;
        public ICriptografia _criptografia;
        public UsuarioServiceApplication(IUsuarioService usuarioService, IMapper mapper, ICriptografia criptografia)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
            _criptografia = criptografia;
        }

        public async Task<UsuarioDTO> Add(UsuarioDTO objeto)
        {
            objeto.Senha = RetornarMD5(objeto.Senha).Result.ToString();
            var map = _mapper.Map<UsuarioDTO, Usuario>(objeto);
            
            await _usuarioService.Add(map);

            var retorno = List().Result.OrderByDescending(o => o.UsuarioId).FirstOrDefault();
            return retorno;
        }

        public async Task<UsuarioDTO> Delete(UsuarioDTO objeto)
        {
            var map = _mapper.Map<UsuarioDTO, Usuario>(objeto);
            await _usuarioService.Delete(map);
            var retorno = GetEntityById(objeto.UsuarioId).Result;
            return retorno;
        }

        public async Task<UsuarioDTO> GetEntityById(int Id)
        {
            var retorno = await _usuarioService.GetEntityById(Id);
            return _mapper.Map<Usuario, UsuarioDTO>(retorno);
        }

        public async Task<UsuarioDTO> GetEntityByName(string nome)
        {
            var retorno = _usuarioService.GetEntityByName(nome);
            return _mapper.Map<Usuario, UsuarioDTO>(retorno);
        }

        public async Task<UsuarioDTO> GetEntityByLogin(string login)
        {
            var retorno = _usuarioService.GetEntityByLogin(login);
            return _mapper.Map<Usuario, UsuarioDTO>(retorno);
        }

        public async Task<bool> RealizarLogin(UsuarioDTO usuarioDTO)
        {
            var retorno = _usuarioService.GetEntityByLogin(usuarioDTO.Login);
            var compSenha = ComparaMD5(retorno.Senha, usuarioDTO.Senha);

            if (compSenha.Result)
                return true;
            else
                return false;
        }

        public async Task<List<UsuarioDTO>> List()
        {
            var retorno = await _usuarioService.List();
            return _mapper.Map<List<Usuario>, List<UsuarioDTO>>(retorno);
        }

        public async Task<UsuarioDTO> Update(UsuarioDTO objeto)
        {
            var map = _mapper.Map<UsuarioDTO, Usuario>(objeto);
            await _usuarioService.Update(map);
            var retorno = GetEntityById(objeto.UsuarioId).Result;
            return retorno;
        }

        public async Task<string> RetornarMD5(string Senha)
        {
            return await _criptografia.RetornarMD5(Senha);
        }

        public async Task<bool> ComparaMD5(string senhabanco, string senha)
        {
            var Senha_MD5 = RetornarMD5(senha);
            return await _criptografia.ComparaMD5(senhabanco, Senha_MD5.Result.ToString());
        }

    }
}
