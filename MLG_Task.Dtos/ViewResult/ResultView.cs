﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLG_Task.Dtos.ViewResult
{
    public class ResultView<TEntity>
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public TEntity? Entity { get; set; }
    }
}