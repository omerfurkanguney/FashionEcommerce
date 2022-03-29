using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //.SingleInstance(); bak
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();

            builder.RegisterType<SizeManager>().As<ISizeService>().SingleInstance();
            builder.RegisterType<EfSizeDal>().As<ISizeDal>().SingleInstance();

            builder.RegisterType<GenderManager>().As<IGenderService>().SingleInstance();
            builder.RegisterType<EfGenderDal>().As<IGenderDal>().SingleInstance();

            builder.RegisterType<FitManager>().As<IFitService>().SingleInstance();
            builder.RegisterType<EfFitDal>().As<IFitDal>().SingleInstance();

            builder.RegisterType<StatusManager>().As<IStatusService>().SingleInstance();
            builder.RegisterType<EfStatusDal>().As<IStatusDal>().SingleInstance();

            builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
            builder.RegisterType<EfCityDal>().As<ICityDal>().SingleInstance();

            builder.RegisterType<CountyManager>().As<ICountyService>().SingleInstance();
            builder.RegisterType<EfCountyDal>().As<ICountyDal>().SingleInstance();

            builder.RegisterType<SubCategoryManager>().As<ISubCategoryService>().SingleInstance();
            builder.RegisterType<EfSubCategoryDal>().As<ISubCategoryDal>().SingleInstance();

            builder.RegisterType<BaseProductManager>().As<IBaseProductService>().SingleInstance();
            builder.RegisterType<EfBaseProductDal>().As<IBaseProductDal>().SingleInstance();

            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<StockManager>().As<IStockService>().SingleInstance();
            builder.RegisterType<EfStockDal>().As<IStockDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
