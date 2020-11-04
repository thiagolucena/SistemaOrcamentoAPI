using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Security.Interfaces
{
    public interface ICriptografia
    {
        Task<string> RetornarMD5(string Senha);
        Task<bool> ComparaMD5(string senhabanco, string Senha_MD5);
    }
}
