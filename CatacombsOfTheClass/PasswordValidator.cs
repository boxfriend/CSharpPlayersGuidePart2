namespace CatacombsOfTheClass;

internal static class PasswordValidator
{
    public static bool ValidatePassword(string password)
    {
        if (password.Length < 6 || password.Length > 13)
            return false;

        var containsUpper = false;
        var constainsLower = false;
        var containsNumber = false;

        foreach(var c in password)
        {
            if (c == 'T' || c == '&')
                return false;

            if(char.IsUpper(c))
                containsUpper = true;

            if(char.IsLower(c))
                constainsLower = true;

            if(char.IsDigit(c))
                containsNumber = true;
        }

        return constainsLower && containsUpper && containsNumber;
    }

}
