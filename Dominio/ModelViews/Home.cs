using Microsoft.AspNetCore.Html;

namespace MinimalApi.Dominio.ModelViews;

public struct Home
{
    public string Mensagem { get => "API Minimal com .NET 7"; }
    
    public String Doc { get => "/swagger"; }
}
