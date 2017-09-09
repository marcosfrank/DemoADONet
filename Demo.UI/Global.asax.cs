using System;
using System.Web;
using AutoMapper;
using Demo.Entities;
using System.Data;

namespace Demo.UI
{
    public class Global : HttpApplication
    {
        #region Methods

        private void Application_Start(object sender, EventArgs e)
        {
            //TODO Quitar el inicializador de este proyecto asi no hace falta la referencia a System.Data.
            Mapper.Initialize(cfg =>
                   cfg.CreateMap<IDataReader, Region>()
                );
        }

        #endregion Methods
    }
}