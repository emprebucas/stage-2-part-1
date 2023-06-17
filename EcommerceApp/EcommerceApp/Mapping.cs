using AutoMapper;
using EcommerceApp.DTOs;
using EcommerceApp.Models;
using EcommerceApp.Entities;

namespace EcommerceApp
{
    /// <summary>
    /// The Mapping class is a subclass of AutoMapper's Profile class, which is used to define mapping configurations.
    /// </summary>
    public class Mapping : Profile
    {
        /// <summary>
        /// Entities, models, and DTOs are often mapped to facilitate the transfer and 
        /// transformation of data between different layers, components, or systems in an application.
        /// </summary>
        public Mapping()
        {
            CreateMap<OrderEntity, OrderModel>().ReverseMap();
            CreateMap<OrderEntity, OrderDto>().ReverseMap();
            CreateMap<OrderModel, OrderDto>().ReverseMap();

            CreateMap<CartItemEntity, CartItemModel>().ReverseMap();
            CreateMap<CartItemEntity, CartItemDto>().ReverseMap();
            CreateMap<CartItemModel, CartItemDto>().ReverseMap();

            CreateMap<UserEntity, UserModel>().ReverseMap();
            CreateMap<UserEntity, UserDto>().ReverseMap();
            CreateMap<UserModel, UserDto>().ReverseMap();
        }
    }
}
