﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loqui
{
    public class ErrorMaskPlaceholder : IErrorMask<ErrorMaskPlaceholder>
    {
        public Exception Overall { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<string> Warnings => throw new NotImplementedException();

        public ErrorMaskPlaceholder Combine(ErrorMaskPlaceholder rhs)
        {
            throw new NotImplementedException();
        }

        public bool IsInError()
        {
            throw new NotImplementedException();
        }

        public void SetNthException(int index, Exception ex)
        {
            throw new NotImplementedException();
        }

        public void SetNthMask(int index, object maskObj)
        {
            throw new NotImplementedException();
        }

        public void ToString(FileGeneration fg)
        {
            throw new NotImplementedException();
        }
    }
}