   M S B A M L   `   `   `  ����P  LBasketballTeamManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:BasketballTeamManager.ViewsBasketballTeamManager.Views  5      .    (BasketballTeamManager.Views.TeamPageView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:BasketballTeamManager.Views     5      
�������.��5	      �   � ColumnDefinitions  5
   
   �� 5      $	��700 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��50 �6   �� 5      $��* �6   .+�5   
   �� -   5        $��	TeamPanel��5      $��0��6&   $��0��63   $��2��6C    �� Orientation$ 
Horizontal=�6W   .+�5      �� -   5        $��TeamLogo��5      �� 5      $ Vertical=�6   $��15q�60   $	��300��6<   .+�5      �� -   5        $��TeamName��5      $��20(�6,   $
��Bold"�6:   �� 5      $ 
Horizontal=�6   .+�5      �� $��Wins: ��6    �� 5      -   5        $��WinsBox��5       �� 5      $��	 Losses: ��6    �� 5      -   5        $��	LossesBox��5       5      5      �� 5      $ 
Horizontal=�6   $��RightToLeft=�62   .+�5      �� -   5        $��	TeamStats��5      $��
Team Stats��6+   $	��100��6@   6L   �� 5       -   5        $��PlayerStats��5       $��Player Stats��6,   $	��100��6C   6O   �� 5!      -   5        $��AllTime��5!      $��AllTime��6(   $	��100��6:   6F   5"      5#      �� 5$   
   $��1��6   $��0��6"   $ 
Horizontal=�62   .+�5%      �� $��Team Roster��6   
���   �$��20(�6>   $��10 10 100 0q�6L   �� 5&      -	   5        $��AddPlayerButton��5&      $��
Add Player��6,   $��10q�6A   $��80��6M   6X   �� 5'      -
   5        $��DeletePlayerButton��5'      $��Delete Player��6/   $��10q�6G   $��80��6S   �� 5(      -   5        $��AddGameButton��5(      $��Add Game��6*   $��10q�6=   $��80��6I   6T   �� 5)      -   5        $��EndSeasonButton��5)      $��
End Season��6,   $��10q�6A   $��80��6M   5*      �� 5+   
   -   5        $��Messages��5+      $��1��6"   $��1��6/   $��2��6?   � 5,   
   -   5        $��Roster��5,      $��2��6   $��0��6*     5-      �� 5.      �� 5/      �� 50      �� 51      �� 52       54      �� 55      �� 56      �� 57      59      5:      5;      