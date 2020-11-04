using ApplicationDTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUsuarioServiceApplication
    {
        Task<UsuarioDTO> Add(UsuarioDTO objeto);
        Task<UsuarioDTO> Update(UsuarioDTO objeto);
        Task<UsuarioDTO> Delete(UsuarioDTO objeto);
        Task<UsuarioDTO> GetEntityById(int Id);
        Task<UsuarioDTO> GetEntityByName(string nome);
        Task<UsuarioDTO> GetEntityByLogin(string login);
        Task<bool> RealizarLogin(UsuarioDTO usuarioDTO);
        Task<List<UsuarioDTO>> List();
        Task<string> RetornarMD5(string Senha);
        Task<bool> ComparaMD5(string senhabanco, string senha);

    }
}
