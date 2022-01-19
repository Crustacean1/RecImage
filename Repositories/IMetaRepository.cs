using RecImage.Models;
namespace RecImage.Repositories{
    interface IMetaRepository{
        MetaData getMetaData(User user,int id);
    }
}