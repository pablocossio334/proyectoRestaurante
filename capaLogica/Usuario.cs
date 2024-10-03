using capaPersitencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace capaLogica
{
    
    public class Usuario
    {
        private string nomUsuario;
        private string pswUsuario;
        private int tipoUsuario;

        public Usuario()
        {
        }

        public Usuario(string nomUsuario, string pswUsuario, int tipoUsuario)
        {
            this.NomUsuario = nomUsuario;
            this.PswUsuario = pswUsuario;
            this.TipoUsuario = tipoUsuario;
        }

        public string NomUsuario { get => nomUsuario; set => nomUsuario = value; }
        public string PswUsuario { get => pswUsuario; set => pswUsuario = value; }
        public int TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }
        public int ObtengoTipoUsuario()
        {
            Conexion c=new Conexion();

            int tipoUsuar = c.ObtenerTipoUsuario(this.NomUsuario, this.PswUsuario);

            return tipoUsuar;
        }
    }
   

    }
   

