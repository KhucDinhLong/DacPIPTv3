using PIPTWeb.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace PIPTWeb.Shared
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionsForModule(string module)
        {
            return new List<string>()
            {
                $"Permissions.{module}.View",
                $"Permissions.{module}.Create",
                $"Permissions.{module}.Edit",
                $"Permissions.{module}.Delete",
                // Các quyền khác
                //$"Permissions.{module}.Approve",
                //$"Permissions.{module}.Override",
                //$"Permissions.{module}.Download",
                //$"Permissions.{module}.Upload",
                //$"Permissions.{module}.Print"
            };
        }

        /// <summary>
        /// Lấy tên lớp theo menu link
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static string ClassNameByLink(string link)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            string className = link;
            link = link.Replace("/", string.Empty);
            if (link.Contains("-"))
            {
                var links = link.Split('-');
                for (int i = 0; i < links.Length; i++)
                {
                    links[i] = textInfo.ToTitleCase(links[i]);
                }
                className = string.Join(string.Empty, links);
            }
            else
            {
                className = textInfo.ToTitleCase(link);
            }
            return className;
        }

        public static List<RoleClaimsViewModel> GetCurrentMenuPermissions(string menuLink, List<RoleClaimsViewModel> roleClaimsViewModels)
        {
            List<RoleClaimsViewModel> allPermissions = new List<RoleClaimsViewModel>();
            //var className = ClassNameByLink(menuLink); gọi như này không chạy!
            Type policy = Type.GetType("OneApp.Shared.Permissions+" + menuLink);
            // Tất cả các quyền trên menu này
            allPermissions.GetPermissions(policy);
            // Tất cả các quyền được gán
            var claims = roleClaimsViewModels.Where(rc => rc.Value.Contains("Permissions." + menuLink)).ToList();
            var allClaimsValues = allPermissions.Select(c => c.Value).ToList();
            var roleClaimValues = claims.Select(c => c.Value).ToList();
            var authorizedClaims = allClaimsValues.Intersect(roleClaimValues).ToList();
            foreach (var permission in allPermissions)
            {
                if (authorizedClaims.Any(a => a == permission.Value))
                {
                    permission.Selected = true;
                }
            }
            return allPermissions;
        }

        public static void GetPermissions(this List<RoleClaimsViewModel> allPermissions, Type policy)
        {
            FieldInfo[] fields = policy.GetFields(BindingFlags.Static | BindingFlags.Public);

            foreach (FieldInfo fi in fields)
            {
                allPermissions.Add(new RoleClaimsViewModel
                {
                    Value = fi.GetValue(null).ToString(),
                    Type = "Permissions",
                    Name = Permissions.GetPermissionName(fi.GetValue(null).ToString()),
                    Selected = false
                });
            }
        }

        public static string GetPermissionName(string claimValue)
        {
            string PermissionName = "Quyền truy cập";
            if (claimValue.EndsWith(".View"))
                PermissionName = "Quyền truy cập";
            if (claimValue.EndsWith(".Create"))
                PermissionName = "Quyền thêm mới";
            if (claimValue.EndsWith(".Edit"))
                PermissionName = "Quyền sửa";
            if (claimValue.EndsWith(".Delete"))
                PermissionName = "Quyền xoá";
            if (claimValue.EndsWith(".Approve"))
                PermissionName = "Quyền phê duyệt";
            if (claimValue.EndsWith(".Override"))
                PermissionName = "Quyền Override";
            if (claimValue.EndsWith(".Download"))
                PermissionName = "Quyền Download";
            if (claimValue.EndsWith(".Upload"))
                PermissionName = "Quyền Upload";
            if (claimValue.EndsWith(".Print"))
                PermissionName = "Quyền Print";
            if (claimValue.EndsWith(".Roles"))
                PermissionName = "Quyền phân nhóm";
            if (claimValue.EndsWith(".Permission"))
                PermissionName = "Quyền thêm quyền";
            if (claimValue.EndsWith(".Finish"))
                PermissionName = "Quyền kết thúc";
            if (claimValue.EndsWith(".Pause"))
                PermissionName = "Quyền tạm dừng";
            if (claimValue.EndsWith(".Continue"))
                PermissionName = "Quyền tiếp tục";
            if (claimValue.EndsWith(".ChangeLSX"))
                PermissionName = "Quyền dừng chèn lệnh";
            if (claimValue.EndsWith(".Save"))
                PermissionName = "Quyền lưu thay đổi";
            if (claimValue.EndsWith(".Cancel"))
                PermissionName = "Quyền hủy thao tác";
            if (claimValue.EndsWith(".Schedule"))
                PermissionName = "Quyền xếp lệnh vào máy";
            return PermissionName;
        }
        public static class Menus
        {
            public const string View = "Permissions.Menus.View";
            public const string Create = "Permissions.Menus.Create";
            public const string Edit = "Permissions.Menus.Edit";
            public const string Delete = "Permissions.Menus.Delete";
        }
        public static class CongTy
        {
            public const string View = "Permissions.CongTy.View";
            public const string Create = "Permissions.CongTy.Create";
            public const string Edit = "Permissions.CongTy.Edit";
            public const string Delete = "Permissions.CongTy.Delete";
        }
        public static class Users
        {
            public const string View = "Permissions.Users.View";
            public const string Create = "Permissions.Users.Create";
            public const string Edit = "Permissions.Users.Edit";
            public const string Delete = "Permissions.Users.Delete";
            public const string Roles = "Permissions.Users.Roles";
        }
        public static class Roles
        {
            public const string View = "Permissions.Roles.View";
            public const string Create = "Permissions.Roles.Create";
            public const string Edit = "Permissions.Roles.Edit";
            public const string Delete = "Permissions.Roles.Delete";
            public const string Permission = "Permissions.Roles.Permission";
        }
        public static class BaoCaoDanhGia
        {
            public const string View = "Permissions.BaoCaoDanhGia.View";
            public const string Download = "Permissions.BaoCaoDanhGia.Download";
        }
        public static class ChiTietDanhGia
        {
            public const string View = "Permissions.ChiTietDanhGia.View";
        }
        public static class ChiTieuDanhGia
        {
            public const string View = "Permissions.ChiTieuDanhGia.View";
            public const string Create = "Permissions.ChiTieuDanhGia.Create";
            public const string Edit = "Permissions.ChiTieuDanhGia.Edit";
            public const string Delete = "Permissions.ChiTieuDanhGia.Delete";
        }
        public static class ChucVu
        {
            public const string View = "Permissions.ChucVu.View";
            public const string Create = "Permissions.ChucVu.Create";
            public const string Edit = "Permissions.ChucVu.Edit";
            public const string Delete = "Permissions.ChucVu.Delete";
        }
        public static class DanhGiaNhanVien
        {
            public const string View = "Permissions.DanhGiaNhanVien.View";
            public const string Create = "Permissions.DanhGiaNhanVien.Create";
        }
        public static class PhongBan
        {
            public const string View = "Permissions.PhongBan.View";
            public const string Create = "Permissions.PhongBan.Create";
            public const string Edit = "Permissions.PhongBan.Edit";
            public const string Delete = "Permissions.PhongBan.Delete";
        }
        public static class Xuong
        {
            public const string View = "Permissions.Xuong.View";
            public const string Create = "Permissions.Xuong.Create";
            public const string Edit = "Permissions.Xuong.Edit";
            public const string Delete = "Permissions.Xuong.Delete";
        }
        public static class NhanVien
        {
            public const string View = "Permissions.NhanVien.View";
            public const string Create = "Permissions.NhanVien.Create";
            public const string Edit = "Permissions.NhanVien.Edit";
            public const string Delete = "Permissions.NhanVien.Delete";
        }
        public static class NhomChiTieu
        {
            public const string View = "Permissions.NhomChiTieu.View";
            public const string Create = "Permissions.NhomChiTieu.Create";
            public const string Edit = "Permissions.NhomChiTieu.Edit";
            public const string Delete = "Permissions.NhomChiTieu.Delete";
        }
        public static class Machines
        {
            public const string View = "Permissions.Machines.View";
            public const string Create = "Permissions.Machines.Create";
            public const string Edit = "Permissions.Machines.Edit";
            public const string Delete = "Permissions.Machines.Delete";
            public const string Roles = "Permissions.Machines.Roles";
        }
        public static class UploadExcelTienDoSanXuat
        {
            public const string View = "Permissions.UploadExcelTienDoSanXuat.View";
            public const string Upload = "Permissions.UploadExcelTienDoSanXuat.Upload";
            public const string Create = "Permissions.UploadExcelTienDoSanXuat.Create";
        }
        public static class LenhSanXuatCuaMay
        {
            public const string View = "Permissions.LenhSanXuatCuaMay.View";
            public const string Finish = "Permissions.LenhSanXuatCuaMay.Finish";
            public const string Pause = "Permissions.LenhSanXuatCuaMay.Pause";
            public const string Continue = "Permissions.LenhSanXuatCuaMay.Continue";
            public const string ChangeLSX = "Permissions.LenhSanXuatCuaMay.ChangeLSX";
            public const string Save = "Permissions.LenhSanXuatCuaMay.Save";
            public const string Cancel = "Permissions.LenhSanXuatCuaMay.Cancel";
            public const string AddError = "Permissions.LenhSanXuatCuaMay.Create";
        }
        public static class Schedules
        {
            public const string View = "Permissions.Schedules.View";
            public const string Create = "Permissions.Schedules.Create";
            public const string Edit = "Permissions.Schedules.Edit";
            public const string Delete = "Permissions.Schedules.Delete";
            public const string Schedule = "Permissions.Schedules.Schedule";
        }
        public static class LoiSanXuat
        {
            public const string View = "Permissions.LoiSanXuat.View";
            public const string Create = "Permissions.LoiSanXuat.Create";
            public const string Edit = "Permissions.LoiSanXuat.Edit";
            public const string Delete = "Permissions.LoiSanXuat.Delete";
        }
        public static class LenhDaXong
        {
            public const string View = "Permissions.LenhDaXong.View";
            public const string Download = "Permissions.Download.Delete";
        }
        public static class ChiTietCongDoan
        {
            public const string View = "Permissions.ChiTietCongDoan.View";
            public const string Create = "Permissions.ChiTietCongDoan.Create";
            public const string Edit = "Permissions.ChiTietCongDoan.Edit";
            public const string Delete = "Permissions.ChiTietCongDoan.Delete";
        }
        public static class TienDoSanXuat
        {
            public const string View = "Permissions.TienDoSanXuat.View";
        }
        public static class DanhSachMaySx
        {
            public const string View = "Permissions.DanhSachMaySx.View";
        }
        public static class Units
        {
            public const string View = "Permissions.Units.View";
            public const string Create = "Permissions.Units.Create";
            public const string Edit = "Permissions.Units.Edit";
            public const string Delete = "Permissions.Units.Delete";
        }
        public static class GroupDevices
        {
            public const string View = "Permissions.GroupDevices.View";
            public const string Create = "Permissions.GroupDevices.Create";
            public const string Edit = "Permissions.GroupDevices.Edit";
            public const string Delete = "Permissions.GroupDevices.Delete";
        }
        public static class PrintersCartridges
        {
            public const string View = "Permissions.PrintersCartridge.View";
            public const string Create = "Permissions.PrintersCartridge.Create";
            public const string Edit = "Permissions.PrintersCartridge.Edit";
            public const string Delete = "Permissions.PrintersCartridge.Delete";
        }
        public static class BaoCaoThayMuc
        {
            public const string View = "Permissions.BaoCaoThayMuc.View";
            public const string Create = "Permissions.BaoCaoThayMuc.Create";
            public const string Edit = "Permissions.BaoCaoThayMuc.Edit";
            public const string Delete = "Permissions.BaoCaoThayMuc.Delete";
        }

        public static class BaoCaoMucDaDung
        {
            public const string View = "Permissions.BaoCaoMucDaDung.View";           
        }

        public static class BaoCaoTinhTrangMuc
        {
            public const string View = "Permissions.BaoCaoTinhTrangMuc.View";
        }
        
        public static class BaoCaoSoGiayDaIn
        {
            public const string View = "Permissions.BaoCaoSoGiayDaIn.View";
        }

        public static class AssignMe
        {
            public const string View = "Permissions.AssignMe.View";
            public const string Edit = "Permissions.AssignMe.Edit";
        }
        public static class FollowRequest
        {
            public const string View = "Permissions.FollowRequest.View";
            public const string Edit = "Permissions.FollowRequest.Edit";
        }
        public static class MyRequest
        {
            public const string View = "Permissions.MyRequest.View";
            public const string Create = "Permissions.MyRequest.Create";
            public const string Edit = "Permissions.MyRequest.Edit";
            public const string Delete = "Permissions.MyRequest.Delete";
        }
        public static class MyDepartmentRequest
        {
            public const string View = "Permissions.MyRequest.View";
        }

        public static class BaoCaoYeuCau
        {
            public const string View = "Permissions.BaoCaoYeuCau.View";
        }

        public static class BaoCaoThietBiPhongBan
        {
            public const string View = "Permissions.BaoCaoThietBiPhongBan.View";
            public const string Create = "Permissions.BaoCaoThietBiPhongBan.Create";
            public const string Edit = "Permissions.BaoCaoThietBiPhongBan.Edit";
            public const string Delete = "Permissions.BaoCaoThietBiPhongBan.Delete";
        }
        public static class Statuses
        {
            public const string View = "Permissions.Statuses.View";
            public const string Create = "Permissions.Statuses.Create";
            public const string Edit = "Permissions.Statuses.Edit";
            public const string Delete = "Permissions.Statuses.Delete";
        }
        public static class Announcement
        {
            public const string View = "Permissions.Announcement.View";
            public const string Create = "Permissions.Announcement.Create";
            public const string Edit = "Permissions.Announcement.Edit";
            public const string Delete = "Permissions.Announcement.Delete";
        }
        public static class LenhMang
        {
            public const string View = "Permissions.LenhMang.View";
        }
    }
}