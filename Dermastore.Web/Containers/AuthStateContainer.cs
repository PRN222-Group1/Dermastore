using Dermastore.Application.DTOs;
using MediatR;

namespace Dermastore.Web.Containers
{
    public class AuthStateContainer
    {
        private AuthDto? _auth;

        public AuthStateContainer()
        {
        }

        public AuthDto Auth
        {
            get => _auth ?? new AuthDto();
            private set
            {
                _auth = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        public void AuthorizeCurrentUser(int id, string role)
        {
            Auth = new AuthDto
            {
                Id = id,
                Role = role,
                IsAuthenticated = true
            };
        }

        public async Task UnauthorizeUserAsync()
        {
            if (_auth != null)
            {
                Auth = new AuthDto();
                Auth.IsAuthenticated = false;
            }

            NotifyStateChanged();
        }
    }
}
