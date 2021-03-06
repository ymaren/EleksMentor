﻿using Core.Dal.Ado.Net;
using Entity;
using ProductStore.Infustructure;
using ProductStore.Model;
using ProductStore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace StoreWeb.Models
{
    public class DBContext:IDisposable
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["DefaultAdoNet"].ConnectionString;
        IObjectFactory _factory;
        ObjectFactoryBuilder builder;

        
        public IProductView Products
        {
            get
            {
                return _factory.Creates<IProductView>();
            }
        }
        public IProductGroupView ProductGroup
        {
            get
            {
                return _factory.Creates<IProductGroupView>();
            }
        }
        public IProductCategoryView ProductCategory
        {
            get
            {
                return _factory.Creates<IProductCategoryView>();
            }
        }

        public IUserView User
        {
            get
            {
                return _factory.Creates<IUserView>();
            }
        }
        public IUsersRoleView UserRole
        {
            get
            {
                return _factory.Creates<IUsersRoleView>();
            }
        }
        public IUserCredentionalView UserCredantials
        {
            get
            {
                return _factory.Creates<IUserCredentionalView>();
            }
        }

        public IOrderTypeView OrderType
        {
            get
            {
                return _factory.Creates<IOrderTypeView>();
            }
        }

        public IOrderHView Orders
        {
            get
            {
                return _factory.Creates<IOrderHView>();
            }
        }



        public DBContext()
        {
            builder = new ObjectFactoryBuilder();
            builder.AddSource(new AdoRepositoryFactory(connectionString));
            _factory = builder.Build();
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
            
        }
    }
}