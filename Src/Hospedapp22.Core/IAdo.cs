using System.Collections.Generic;
using Hospedapp22.Core;

namespace Hospedapp22.Core.Ado
{
    public interface IAdo
    {
        void AltaHotel(Hotel hotel);
        List<Hotel> ObtenerHotel();
    }
}


/*
dotnet add Src\HospedApp.AdoMySQL\HospedApp.AdoMySQL.csproj reference Src\Hospedapp22.Core\Hospedapp22.Core.csproj
*/