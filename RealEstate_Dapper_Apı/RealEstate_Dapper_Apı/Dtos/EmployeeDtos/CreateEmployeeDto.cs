﻿namespace RealEstate_Dapper_API.Dtos.EmployeeDtos
{
    public class CreateEmployeeDto
    {
        public string EmployeeName { get; set; }
        public string Title { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
