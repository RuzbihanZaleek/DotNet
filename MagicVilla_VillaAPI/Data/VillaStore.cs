﻿using MagicVilla_VillaAPI.Models.Dto;

namespace MagicVilla_VillaAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDto> villaList = new List<VillaDto>
            {
                new VillaDto{ Id=1, Name="Pool Villa"},
                new VillaDto{ Id=2, Name="Beach Villa"}
            };
    }
}
