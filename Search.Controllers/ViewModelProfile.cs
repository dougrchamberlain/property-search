using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Search.Data.Models;
using Search.Helpers;
using Search.Components.Html.ViewModels; 


namespace Search.Helpers.AutoMapper
{

    public class ViewModelProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                
                return "ViewModel";
            }
        }

        protected override void Configure()
        {
         //TODO: Add Mappings from Models to Data Objects 

            CreateMap<Parcel, ParcelViewModel>();
            CreateMap<IEnumerable<Characteristic>, ParcelViewModel>();
            CreateMap<IEnumerable<Building>, ParcelViewModel>();
            CreateMap<IEnumerable<Transfer>, ParcelViewModel>();
            CreateMap<IEnumerable<ExtraFeature>, ParcelViewModel>();
            CreateMap<IEnumerable<Exemption>, ParcelViewModel>();
            CreateMap<IEnumerable<ParcelValuation>, ParcelViewModel>();
            CreateMap<IEnumerable<AdValorem>, ParcelViewModel>();
            CreateMap<IEnumerable<NonAdValorem>, ParcelViewModel>();
            CreateMap<IEnumerable<Owner>, ParcelViewModel>();

            CreateMap<Building, BuildingViewModel>().ForMember(m=>m.HALF_BATHS,o=>o.MapFrom(s=>s.HalfBaths));
            CreateMap<IEnumerable<StructuralElement>, BuildingViewModel>();
            CreateMap<IEnumerable<ExtraFeature>, BuildingViewModel>();
            CreateMap<IEnumerable<SubArea>, BuildingViewModel>();

            CreateMap<Parcel, ParcelResultItemViewModel >();
            CreateMap<Tangible, TangibleResultItemViewModel>();


            //Names are the same in domain and viewModel

           
        }

    }

}