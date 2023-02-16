using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TacoBellAPI;

public partial class Burrito
{

    public int Id { get; set; }

    public string? Name { get; set; }

    public float? Cost { get; set; }

    public bool? Bean { get; set; }
}
