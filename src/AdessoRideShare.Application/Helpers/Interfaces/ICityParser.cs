using AdessoRideShare.Application.Model;

namespace AdessoRideShare.Application.Helpers.Interfaces
{
    public interface ICityParser
    {
        City GetCityFrom(string value);
    }
}