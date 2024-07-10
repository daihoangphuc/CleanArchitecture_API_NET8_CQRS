using AutoMapper;

namespace CleanArchitecture.Application.Common.Mappings
{
    public class NullValueIgnoringConverter<TSource, TDestination> : ITypeConverter<TSource, TDestination>
        where TDestination : class
    {
        public TDestination Convert(TSource source, TDestination destination, ResolutionContext context)
        {
            if (destination == null)
                destination = Activator.CreateInstance<TDestination>();

            foreach (var sourceProperty in typeof(TSource).GetProperties())
            {
                var destinationProperty = typeof(TDestination).GetProperty(sourceProperty.Name);

                if (destinationProperty != null && destinationProperty.CanWrite)
                {
                    var sourceValue = sourceProperty.GetValue(source);
                    var destinationValue = destinationProperty.GetValue(destination);

                    if (sourceValue != null)
                    {
                        destinationProperty.SetValue(destination, sourceValue);
                    }
                    else if (destinationValue != null)
                    {
                        destinationProperty.SetValue(destination, destinationValue);
                    }
                }
            }

            return destination;
        }
    }
}
