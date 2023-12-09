
using Microsoft.AspNetCore.Mvc;

namespace Patients.Controllers;
public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}