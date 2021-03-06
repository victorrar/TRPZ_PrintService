﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TRPZ_PrintService.Areas.Identity.Data;

namespace TRPZ_PrintService.Areas.Identity.Pages.Account.Manage
{
    public class PersonalDataModel : PageModel
    {
        private readonly ILogger<PersonalDataModel> _logger;
        private readonly UserManager<TRPZ_PrintServiceUser> _userManager;

        public PersonalDataModel(
            UserManager<TRPZ_PrintServiceUser> userManager,
            ILogger<PersonalDataModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

            return Page();
        }
    }
}