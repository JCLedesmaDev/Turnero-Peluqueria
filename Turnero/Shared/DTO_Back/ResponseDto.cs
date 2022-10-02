namespace Turnero.Shared.DTO_Back
{
    public class ResponseDto<TypeData>
    {
        public TypeData result { get; set; }
        public string messageError { get; set; }
    }
}
