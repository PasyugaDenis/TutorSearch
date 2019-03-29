using Microsoft.AspNetCore.Mvc;

namespace TutorSearch.Helpers
{
    public static class JsonResults
    {
        public static ActionResult Success()
        {
            return Json(new { success = true });
        }

        public static ActionResult Success(object data)
        {
            return Json(new { success = true, data });
        }

        public static ActionResult Error(int errorNum = 0, string errorMessage = "")
        {
            return Json(new { success = false, errorNum, errorMessage });
        }

        private static JsonResult Json(object data)
        {
            return new JsonResult(data);
        }
    }
}
