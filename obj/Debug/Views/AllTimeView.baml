   M S B A M L   `   `   `  ����P  LBasketballTeamManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:BasketballTeamManager.ViewsBasketballTeamManager.Views  5      -    'BasketballTeamManager.Views.AllTimeView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:BasketballTeamManager.Views     5      .��5	      � 
�������  � ColumnDefinitions  5
   
   �� 5      $	��750 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��FranchisePlayerTable��5         
IsReadOnly .    CanUserAddRows .     AutoGenerateColumns .  $��0��6�   $��2��6�   ��6/   �� *
playerList+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Player��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Name+  5      $	 Pos��6%    62   �� *
Position+  5      $
 From��6%    63   �� *	Country+  5      $	 Yrs��6%    62   �� *Years+  5      $ G��6%    60   �� *Games+  5      $ MP��6%    61   �� *MinutesPlayed+  5      $ FG��6%    61   �� *
FieldGoals+  5      $	 FGA��6%    62   �� *FieldGoalsAttempts+  5      $ 3P��6%    61   �� *ThreePointGoals+  5      $	 3PA��6%    62   �� *ThreePointGoalsAttempts+  5      $ FT��6%    61   �� *
FreeThrows+  5      $	 FTA��6%    62   �� *FreeThrowsAttempts+  5       $	 ORB��6%    62   �� *OffensiveRebounds+  5!      $	 TRB��6%    62   �� *TotalRebounds+  5"      $	 AST��6%    62   �� *	Assists+  5#      $	 STL��6%    62   �� *Steals+  5$      $	 BLK��6%    62   �� *Blocks+  5%      $	 TOV��6%    62   �� *	Turnovers+  5&      $ PF��6%    61   �� *PersonalFauls+  5'      $	 PTS��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 62    6<   �� *Points+5)      �� 5*   
   $��1��6   	 �� Orientation$	 Vertical=�6%   .+�5+      �� $	 
Horizontal=�6   $��0,0,0,10q�62   .+�5,      �� $��95��6   $��Totals/PerGame��6#   $��0,0,5,0q�6<   �� 5-      -   5        
 ��Name$
 TotalsPerGame��5-      $	��100��62   .@�5.      �� $��Totals��6#    �� 
IsSelected . 64   �� 5/      $��PerGame��6#   50      51      �� 52      $	 
Horizontal=�6   $��0,0,0,10q�62   .+�53      �� $��95��6   $��Records��6#   $��0,0,5,0q�65   �� 54      -   5        $
 RecordsSelection��54      $	��100��65   .@�55      �� -   5        $	��pts��55   #   $��Points��6.    . 6?   �� 56      -   5        $��fg��56   #   $��Field goals��6-   �� 57      -   5        $	��fg3��57   #   $��	3pt goals��6.   �� 58      -   5        $	��trb��58   #   $��Rebounds��6.   �� 59      -   5        $	��ast��59   #   $��Assists��6.   �� 5:      -	   5        $	��blk��5:   #   $��Blocks��6.   �� 5;      -
   5        $	��stl��5;   #   $��Steals��6.   �� 5<      -   5        $	��tov��5<   #   $��	Turnovers��6.   5=      5>        5?      -   5        $��Records��5?      $
��auto��6&    � 	Resources 5@      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn �� 
TargetType �� Property   
Background �� Value  
Foreground��%{   '        7 �� 5A      8   "  6U   .�5B      ��  � ��# �   67   �� 5C       � ��# �  67   5D      5E       5F        5G      $ Player��6)    69   �� *name+  5H      $
 Date��6)    67   �� *date+  5I      $	 Pts��6)   $ * 66    6@   �� *score+5K      5L      �� 5M   
   -   5        $��1��5M      $��1��6!   $
��Back��6.   $	��100��6=   $��35��6I   $��	0 230 0 0q�6U   6h   5N      5O      