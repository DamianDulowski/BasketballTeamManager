   M S B A M L   `   `   `  ����P  LBasketballTeamManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:BasketballTeamManager.ViewsBasketballTeamManager.Views  5      2    ,BasketballTeamManager.Views.CreatePlayerView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:BasketballTeamManager.Views     5      
�������.��5	      � .+�5
   
   �� .+�5      �� -   5        $��TopPanel��5      $��60��6%   $
��1000��61   ._�5      �� -   5        $��TextTopPanel��5      $��Add new Player��60   $��30(�6F   $��Champagne & Limousines)�6T   $
��Bold"�6|   $��200 5 200 5q�6�   5      �� 5        �� Orientation$  
Horizontal=�6   .+�5      �� .+�5      �� $��
First Name��6    $��15(�62   $��200 20 200 0q�6A   �� 5      -   5        $��FirstNameTextBox��5      $��15(�66   $��30��6D   $��
200 5 0 00q�6Q   5      �� 5      $	��330��6   .+�5      �� $��	Last Name��6    $��15(�61   $��45 20 200 0q�6@   �� 5      -   5        $��LastNameTextBox��5      $��15(�65   $��30��6C   $��45 5 0 0q�6P   5      5      �� 5      $  
Horizontal=�6   .+�5      �� .+�5      �� $��Country Name��6    $��15(�64   $��200 20 200 0q�6C   �� 5      -   5        $��CountryTextBox��5      $��15(�64   $��30��6B   $��
200 5 0 30q�6O   $	��416��6c   5      �� 5      $	��382��6   .+�5       �� $	��Age��6    $��15(�6+   $��45 20 200 0q�6:   �� 5!      -   5        $��
AgeTextBox��5!      $��15(�60   $��30��6>   $��45,5,200,20q�6J   6_   5"      5#      �� 5%      $  
Horizontal=�6   .+�5&      �� $  Vertical=�6   .+�5'      �� $��Player picture��6    $��15(�66   $��
200 0 0 10q�6D   �� 5(      -   5        $��Select image��5(      
����������#333333$��30��6\   $	��100��6h   $��	200 0 0 0q�6�   5)      �� 5*      $��	20 0 0 0 q�6   $	��150��6,   $	��150��68   $��1q�6E   ���#333333._�5+      �� -   5        $��PlayerImage��5+      $	��150��60   $	��150��6<   $@��:/BasketballTeamManager;component/Assets/defaultPicture.png��6I   $
��Fill=�6�   5,      �� 5-      $  Vertical=�6   .+�5.      �� $��Position��6    $��15(�60   $��50 0 0 0q�6?   �� 5/      -	   5        $��PositionBox��5/      $��	50 10 0 0q�62   $��65��6E   .@�50      �� $��PG��6'    �� 
IsSelected . 64   �� 51      $��SG��6'   �� 52      $��SF��6'   �� 53      $��PF��6'   �� 54      $��C��6'   55      56      �� 57      $  Vertical=�6   .+�58      �� $��Height��6    $��15(�6.   $��40 0 0 0q�6<   �� 59      -
   5        $��	HeightBox��59      $��25��6/   $��65��6;   $��	40 10 0 0q�6F   6Y   5:      �� 5;      $  Vertical=�6   .+�5<      �� $��Weight��6    $��15(�6.   $��
40 0 200 0q�6<   �� 5=      -   5        $��	WeightBox��5=      $��25��6/   $��65��6;   $��40 10 200 0q�6F   6[   5>      5?      �� 5@      $  
Horizontal=�6   $��	0 100 0 0q�62   .+�5A      �� -   5        $��CanelButton��5A      $��Canel��6,   $��50��6<   $	��200��6H   $��20(�6T   $
��Bold"�6b   $��	200 0 0 0q�6�   �� 5B      -   5        $��AddPlayerButton��5B      $��
Add Player��61   $��50��6F   $	��200��6R   $��20(�6^   $
��Bold"�6l   $��200 0 200 0q�6�   5C      5D      5E      5F      