using Domain.Interfaces.IRepository;
using Domain.Interfaces.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class UsuarioService : GenericService<Usuario>, IUsuarioService
    {

        public readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
            : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario GetEntityByLogin(string login)
        {
            return _usuarioRepository.GetEntityByLogin(login);
        }

        public Usuario GetEntityByName(string nome)
        {
            return _usuarioRepository.GetEntityByName(nome);
        }
    }
}
