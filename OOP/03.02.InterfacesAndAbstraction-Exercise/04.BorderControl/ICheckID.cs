﻿namespace _04.BorderControl
{
    public interface ICheckID
    {
        public string ID { get; set; }

        public bool IsNotValidID(string endOfID);
    }
}
