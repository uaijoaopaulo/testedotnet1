using testedotnet1.WebAPI.Model.App_Data;

namespace testedotnet1.WebAPI.Horas
{
    public class BaseRepository
    {
        private HorasContext _DataModel;
        public HorasContext DataModel
        {
            get
            {
                if (_DataModel == null)
                    _DataModel = new HorasContext();
                return _DataModel;
            }
        }
    }
}
