
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

                // cfg.CreateMap<Usuario, UsuarioViewmodel>()
                //  .ForMember(dest => dest.NomeEmpresa, map => map.MapFrom(orig => orig.Empresa.Nome));

                // cfg.CreateMap<UsuarioViewmodel, Usuario>();

                #endregion




            });
        }
    }
}
