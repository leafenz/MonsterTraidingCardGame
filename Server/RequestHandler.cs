using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterTradingCardGame.Server
{
    public class RequestHandler
    {
        private static Dictionary<string, string> users = new Dictionary<string, string>();
        private static Dictionary<string, string> tokens = new Dictionary<string, string>();

        public static (string Status, string ContentType, string Body) HandleRequest(string request)
        {
            string method = ExtractMethod(request);
            string endpoint = ExtractEndpoint(request);
            var parameters = ExtractParameters(request);
            string token = ExtractTokenFromHeaders(request);

            if (endpoint == "/register" && method == "POST")
            {
                return HandleRegister(parameters);
            }
            else if (endpoint == "/login" && method == "POST")
            {
                return HandleLogin(parameters);
            }
            else if (endpoint == "/user_data" && method == "GET")
            {
                return HandleUserData(token);
            }
            else
            {
                return ("404 Not Found", "text/plain", "Seite nicht gefunden");
            }
        }

        private static (string Status, string ContentType, string Body) HandleRegister(Dictionary<string, string> parameters)
        {
            if (!parameters.ContainsKey("username") || !parameters.ContainsKey("password"))
            {
                return ("400 Bad Request", "text/plain", "Fehlende Parameter");
            }

            string username = parameters["username"];
            string password = parameters["password"];

            if (users.ContainsKey(username))
            {
                return ("409 Conflict", "text/plain", "Benutzer existiert bereits");
            }

            users[username] = password;
            return ("200 OK", "text/plain", "Benutzer erfolgreich registriert!");
        }

        private static (string Status, string ContentType, string Body) HandleLogin(Dictionary<string, string> parameters)
        {
            if (!parameters.ContainsKey("username") || !parameters.ContainsKey("password"))
            {
                return ("400 Bad Request", "text/plain", "Fehlende Parameter");
            }

            string username = parameters["username"];
            string password = parameters["password"];

            if (!users.ContainsKey(username) || users[username] != password)
            {
                return ("401 Unauthorized", "text/plain", "Ungültige Anmeldedaten");
            }

            string token = Guid.NewGuid().ToString();
            tokens[username] = token;
            return ("200 OK", "text/plain", $"Erfolgreich eingeloggt! Token: {token}");
        }

        private static (string Status, string ContentType, string Body) HandleUserData(string token)
        {
            if (string.IsNullOrWhiteSpace(token) || !tokens.ContainsValue(token))
            {
                return ("401 Unauthorized", "text/plain", "Ungültiger Token");
            }

            string username = tokens.FirstOrDefault(x => x.Value == token).Key;

            if (string.IsNullOrEmpty(username))
            {
                return ("401 Unauthorized", "text/plain", "Ungültiger Token");
            }

            return ("200 OK", "application/json", $"{{\"username\": \"{username}\", \"data\": \"Beispiel-Daten...\"}}");
        }

        private static string ExtractMethod(string request)
        {
            return request.Split(' ')[0];
        }

        private static string ExtractEndpoint(string request)
        {
            return request.Split(' ')[1];
        }

        private static Dictionary<string, string> ExtractParameters(string request)
        {
            var parameters = new Dictionary<string, string>();
            string body = GetRequestBody(request);
            var pairs = body.Split('&');

            foreach (var pair in pairs)
            {
                var parts = pair.Split('=');
                if (parts.Length == 2)
                {
                    string key = Uri.UnescapeDataString(parts[0]);
                    string value = Uri.UnescapeDataString(parts[1]);
                    parameters[key] = value;
                }
            }
            return parameters;
        }

        private static string ExtractTokenFromHeaders(string request)
        {
            var headers = request.Split(new[] { "\r\n" }, StringSplitOptions.None);
            foreach (var header in headers)
            {
                if (header.StartsWith("Authorization:"))
                {
                    string[] parts = header.Split(' ');
                    if (parts.Length == 3 && parts[0] == "Authorization:" && parts[1] == "Bearer")
                    {
                        return parts[2];
                    }
                }
            }
            return string.Empty;
        }

        private static string GetRequestBody(string request)
        {
            int index = request.IndexOf("\r\n\r\n");
            return index != -1 ? request.Substring(index + 4) : string.Empty;
        }
    }
}
