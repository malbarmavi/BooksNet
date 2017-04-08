﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksNet.Models
{
  public class Category
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public List<Book> Books { get; set; }

    [Timestamp]
    public byte[] Version { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime LastUpdate { get; set; }
  }
}