namespace Employees.classes;

public class Employee{

    // public int empno {get ;set;}
    // public string? name {get; set;}
    // public string? city { get; set; }

    public int empNo; 
    public string? name; 
    public string? city;

    //constructor
    public Employee(int _empno, string _name, string _city)
    {
        empNo = _empno;
        name = _name;
        city = _city;
    }

    public string GetEmployees(){
        return empNo+ " "+ name+ " "+ city;
    }

    public void SetEmployee(){
        // set emp data
    }
}