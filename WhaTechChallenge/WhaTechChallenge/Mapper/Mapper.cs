﻿namespace WhaTechChallenge.Mapper
{
    public class Mapper : IMapper
    {
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return AutoMapper.Mapper.Map<TDestination>(source);
        }
    }
}