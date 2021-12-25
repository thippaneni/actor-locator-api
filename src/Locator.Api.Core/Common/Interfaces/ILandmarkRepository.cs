using Locator.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Api.Core.Common.Interfaces
{
    public interface ILandmarkRepository
    {
        Task<IEnumerable<Landmark>> GetAllLandMarksAsync();

        Task<int?> GetDistanceAsync(Landmark startingLandMark, Landmark endingLandMark, IEnumerable<Landmark> viaLandMarks);

        Task<IEnumerable<Landmark>> GetAdjecentLandMarksAsync(Landmark landmark);
    }
}
