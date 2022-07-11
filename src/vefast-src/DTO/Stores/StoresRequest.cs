using System;
namespace vefast_src.DTO.Stores
{
    public class StoresRequest
    {           
            public string Name { get; set; }
            public bool Active { get; set; }
            public Guid ID_Company { get; set; }        
    }
}
