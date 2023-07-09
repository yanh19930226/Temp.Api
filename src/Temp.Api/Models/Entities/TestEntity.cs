namespace Temp.Api.Models.Entities
{
    /// <summary>
    /// TestEntity
    /// </summary>
    [SugarTable("sys_menu")]
    public class TestEntity : SqlSugarEntity
    {
        /// <summary>
        /// 编号
        /// </summary>
        [SugarColumn(ColumnDescription = "code", ColumnName = "code")]
        public string Code { get; set; } = string.Empty;
        /// <summary>
        /// 組件配置
        /// </summary>
        [SugarColumn(ColumnDescription = "component", ColumnName = "component")]
        public string? Component { get; set; } = string.Empty;

        /// <summary>
        /// 是否隐藏
        /// </summary>
        [SugarColumn(ColumnDescription = "hidden", ColumnName = "hidden")]
        public bool Hidden { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [SugarColumn(ColumnDescription = "icon", ColumnName = "icon")]
        public string? Icon { get; set; }

        /// <summary>
        /// 是否是菜单1:菜单,0:按钮
        /// </summary>
        [SugarColumn(ColumnDescription = "ismenu", ColumnName = "ismenu")]
        public bool IsMenu { get; set; }

        /// <summary>
        /// 是否默认打开1:是,0:否
        /// </summary>
        [SugarColumn(ColumnDescription = "isopen", ColumnName = "isopen")]
        public bool IsOpen { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        [SugarColumn(ColumnDescription = "levels", ColumnName = "levels")]
        public int Levels { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(ColumnDescription = "name", ColumnName = "name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 序号
        /// </summary>
        [SugarColumn(ColumnDescription = "ordinal", ColumnName = "ordinal")]

        public int Ordinal { get; set; }

        /// <summary>
        /// 父菜单编号
        /// </summary>
        [SugarColumn(ColumnDescription = "pcode", ColumnName = "pcode")]

        public string PCode { get; set; } = string.Empty;

        /// <summary>
        /// 递归父级菜单编号
        /// </summary>
        [SugarColumn(ColumnDescription = "pcodes", ColumnName = "pcodes")]
        public string PCodes { get; set; } = string.Empty;

        /// <summary>
        /// 状态1:启用,0:禁用
        /// </summary>
        [SugarColumn(ColumnDescription = "status", ColumnName = "status")]
        public bool Status { get; set; }

        /// <summary>
        /// 鼠标悬停提示信息
        /// </summary>
        [SugarColumn(ColumnDescription = "tips", ColumnName = "tips")]
        public string? Tips { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        [SugarColumn(ColumnDescription = "url", ColumnName = "url")]
        public string Url { get; set; } = string.Empty;
    }
}
