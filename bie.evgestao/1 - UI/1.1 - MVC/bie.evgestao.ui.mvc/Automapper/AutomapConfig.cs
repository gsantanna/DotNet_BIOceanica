
using System.Collections.Generic;
using AutoMapper;
using bie.evgestao.domain.Entities;
using bie.evgestao.ui.viewmodels;
using System.Linq;
using bie.mvc.utilities;

namespace bie.evgestao.ui.mvc.AutoMapper
{
    public static class AutomapConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {

                #region USUARIO

                cfg.CreateMap<Usuario, UsuarioViewmodel>();
                cfg.CreateMap<UsuarioViewmodel, Usuario>();

                #endregion


                #region PESSOA 
                cfg.CreateMap<Pessoa, PessoaViewmodel>();
                cfg.CreateMap<PessoaViewmodel, Pessoa>();
                #endregion





            });
        }
    }
}
