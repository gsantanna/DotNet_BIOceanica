
using System.Collections.Generic;
using AutoMapper;
using bie.evgestao.domain.Entities;
using bie.evgestao.ui.viewmodels;
using System.Linq;



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


                #region FAMILIAR
                cfg.CreateMap<Familiar, FamiliarViewmodel>();
                cfg.CreateMap<FamiliarViewmodel, Familiar>();
                #endregion


                #region CELULA
                cfg.CreateMap<Celula, CelulaViewmodel>();
                cfg.CreateMap<CelulaViewmodel, Celula>();

                #endregion



            });
        }
    }
}
