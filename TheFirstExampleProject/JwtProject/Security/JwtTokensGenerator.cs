using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtProject.Queries;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace JwtProject.Security;

public class JwtTokensGenerator
{
    
    private readonly string _secretKey;
    
    public JwtTokensGenerator(IConfiguration configuration)   {     
        _secretKey =  configuration["Jwt:Key"] ?? throw new ArgumentNullException("Jwt:Key");  
    } 
    
    public string GenerateJwtToken(LoginQuery query)
    {
        var claims = new Claim[]
        {
            new Claim("id_user", query.id_user.ToString()),
            new Claim("id_role", query.id_role.ToString()),
            
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));  
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); 
        
        var token = new JwtSecurityToken  
        (  
            claims: claims,  
            signingCredentials: creds  
        );    
    
        return new JwtSecurityTokenHandler().WriteToken(token);  
    }
}