using testedotnet1.Data;

namespace testedotnet1.Repository
{
    public class BaseRepository
    {
        private RegistroContext _DataModel;
        public RegistroContext DataModel
        {
            get
            {
                if (_DataModel == null)
                    _DataModel = new RegistroContext();
                return _DataModel;
            }
        }
    }
}
