   M S B A M L   `   `   `  ����D  @TicTacToe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TicTacToe	TicTacToe  5   	   3clr-namespace:TicTacToe.ModelsTicTacToe.Models  5   	       TicTacToe.MainWindow   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:TicTacToe     5   	   1modelsclr-namespace:TicTacToe.Models     5   	      MaterialDesignBody#���   5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � Title$ Tic Tac Toe��5   	   $	��600��6   $	��500��6*    � 
ResizeMode$ NoResize=�66    � WindowStartupLocation$ CenterScreen=�6L    � 	Resources 5      "   TicTacToe.CellValueConverter  CellValueConverter$   TicTacToe.WinnerLabelConverter  WinnerLabelConverter��%:   &	       &	        5   
   6#     5   
   6%   5      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��* �6   �� 5       $��3* �6   �� 5!      $��* �6   �� 5"      $��* �6   .+�5&   
   �� -   5        $��X��5&       $  MaterialDesignRaisedAccentButton#��[ 5'      $	��160��5(      ��5)      �� *PlayersLabel1+{�5+      �� *AllowChoosing+�� 5-   
   -   5        $��O��5-      $��1��5.      #��[ 6!   $	��160��5/      ��50      �� *PlayersLabel2+{�52      �� *AllowChoosing+� 55   
   -   5        $��	GameBoard��55      $��1��6    $��2��6-   $��14q�6A   $	��250��6M   $	��250��6Y    � ShowGridLines$
 True��56      {�6$   �� *EnableGameBoard+ 58      �� 59      �� 5:      �� 5;       5>      �� 5?      �� 5@      �� 5A      .+�5E      �� -   5          GameBoardCell#��[ 5E      ��5F      `� 5G      	 `� 	Converter#	 [ 6#   .1�5H      �� 
 �� Path$
 	GameBoard�6"   �� 5I        row0 �� Source# [ 6"   �� 5J        col0# [ 6"   5K      5M      �� 5O      -   5        #��[ 5O      $��1��6U   ��5P      `� 5Q      #	 [ 6#    `� UpdateSourceTrigger$ PropertyChanged=�6S   .1�5R      �� $
 	GameBoard�6"   �� 5S      # [ 6"   �� 5T       	 col1# [	 6"   5U      5W      �� 5Y      -   5        #��[ 5Y      $��2��6U   ��5Z      `� 5[      #	 [ 6#   $ PropertyChanged=�6S   .1�5\      �� $
 	GameBoard�6"   �� 5]      # [ 6"   �� 5^       
 col2# [
 6"   5_      5a      �� 5d      -   5        #��[ 5d      $��1��6U   $��0��6b   ��5e      `� 5f      #	 [ 6#   $ PropertyChanged=�6S   .1�5g      �� $
 	GameBoard�6"   �� 5h        row1# [ 6"   �� 5i      # [ 6"   5j      5l      �� 5n      -   5        #��[ 5n      $��1��6U   $��1��6b   ��5o      `� 5p      #	 [ 6#   $ PropertyChanged=�6S   .1�5q      �� $
 	GameBoard�6"   �� 5r      # [ 6"   �� 5s      # [	 6"   5t      5v      �� 5x      -	   5        #��[ 5x      $��1��6U   $��2��6b   ��5y      `� 5z      #	 [ 6#   $ PropertyChanged=�6S   .1�5{      �� $
 	GameBoard�6"   �� 5|      # [ 6"   �� 5}      # [
 6"   5~      5�      �� 5�      -
   5        #��[ 5�      $��2��6U   $��0��6b   ��5�      `� 5�      #	 [ 6#   $ PropertyChanged=�6S   .1�5�      �� $
 	GameBoard�6"   �� 5�        row2# [ 6"   �� 5�      # [ 6"   5�      5�      �� 5�      -   5        #��[ 5�      $��2��6U   $��1��6b   ��5�      `� 5�      #	 [ 6#   $ PropertyChanged=�6S   .1�5�      �� $
 	GameBoard�6"   �� 5�      # [ 6"   �� 5�      # [	 6"   5�      5�      �� 5�      -   5        #��[ 5�      $��2��6U   $��2��6b   ��5�      `� 5�      #	 [ 6#   $ PropertyChanged=�6S   .1�5�      �� $
 	GameBoard�6"   �� 5�      # [ 6"   �� 5�      # [
 6"   5�      5�      5�      �� 5�   
    $  MaterialDesignHeadline3TextBlock#��[ 6   
������$��Center=�5�      $��Center=�5�      $��2��5�      $��2��6(   ��5�      �� *Winner+ �� 	Converter# [ y�5�      �� *ShowGameResult+   BooleanToVisibilityConverter# [ �� 5�   
   -   5        $��Reset��5�      $��3��5�      $��2��5�      #��[ 5�      $	��160��5�      $��New Game��5�      5�      5�      5�      