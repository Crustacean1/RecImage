namespace RecImage.Models{
    public class UserInfoDto{
        public UserInfoDto(){}
        public UserInfoDto(User user){
            Login = user.Login;
            Id = user.UserId;
            Images = user.Images;
        }
        public string? Login{get;set;}
        public int Id{get;set;}
        public IEnumerable<MetaData> Images{get;set;}
    }
}