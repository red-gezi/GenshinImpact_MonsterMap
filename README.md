# 原神辅助怪物采集物雷达（GenshinImpact_MonsterMap）
 
## 标记精英怪+采集物，告别查地图的烦恼
## [下载地址（点我）](https://github.com/red-gezi/GenshinImpact_MonsterMap/releases)
# 原理介绍
+ 通过win32api采集原神进程的画面
+ 通过Sift/Surf算法与模板中的大地图做对比，换算游戏窗口下地图对应的矩阵坐标
+ 查询b站wiki中原神地图，通过接口获得所有标记点的坐标和类型信息，并筛选出在矩阵范围内的标记点[连接地址（点我）](https://wiki.biligame.com/ys/%E5%8E%9F%E7%A5%9E%E5%9C%B0%E5%9B%BE%E5%B7%A5%E5%85%B7_%E5%85%A8%E5%9C%B0%E6%A0%87%E4%BD%8D%E7%BD%AE%E7%82%B9)
+ 生成一张透明，鼠标能透过去的图片，将标记点画上去，然后重叠到游戏界面上层
+ 已实号验证使用5天未被封
# 使用说明
打开exe文件（注意，一定要右键，以管理员模式启动，不然原神无法接受模拟输入）
选择显示目标标签
点击open按钮
ps:
+ 可在采集界面检查捕获图片是否完整，上层为采集图片，下层为特征的对比结果，如果是黑屏则是没有用管理员权限打开
+ 标志点与实际位置不匹配可以通过校准页面的数值进行调整

# 使用说明
# 软件界面
+ ![1.png](/img/1.png)
+ ![1.png](/img/1.png)
# 原理介绍
+ ![3.png](/img/3.png)
# 感谢名单
+ [刘博士]（自己fork改地址）(https://github.com/red-gezi/GenshinImpact_MonsterMap/releases)
# 投食码
+ 觉得好用可以请我吃雪糕

+ ![支付宝](/img/pay.png)
