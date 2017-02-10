namespace SimpleHttpServer.Enums
{
    public enum ResponseStatusCode
    {
        Continue = 100,
        Ok = 200,
        BadRequest = 400,
        NotFound = 404,
        InternalServerError = 500,
        NotImplemented = 501,
        MethodNotAllowed = 412
    }
}