﻿using CQRSTest.Entities;

namespace CQRSTest.DTOS;

public class ProductResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
