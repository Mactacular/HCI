   M S B A M L   `   `   `  ����N  JRatingControlSample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullV>clr-namespace:RatingControlSample;assembly=RatingControlSampleRatingControlSample  5      F BZoomExample, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:RatingControlSampleRatingControlSample 5   	      ZoomExample.Window1   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    Jr>clr-namespace:RatingControlSample;assembly=RatingControlSample    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ARatingControlSample!clr-namespace:RatingControlSample     5   	     � Title$  Thanksgiving Turkey��5   	   $	��768��6%   $
��1024��62   ��5      �� 5   
    �� ImageSource$ b6.jpg��6   .��5
      � $��0,0,-60,-109q�6   $	��672��6!    � RowDefinitions 5   
   �� 5      $
��328* �6   �� 5      $	��16* �6   �� 5      $
��403* �6   .+�5   
   �� -   5        $��Recipe��5      $��20(�6"   $	��140��60   $��-13,12,545,401q�6O   $��2��6g   �� 5   
   -   5        $��Ingredients��5      $��20(�6'   $	��140��65   $��127,12,405,401q�6Y   $��2��6q    J� RenderTransformOrigin$ 0.514,1.029&�6~   �� 5   
   -   5        $��Reviews��5      $��20(�6#   $	��140��61   $��267,12,265,401q�6P   $��2��6h   �� 5   
    �� Orientation$ 
Horizontal=�6   $��89,349,163,453q�6.   $��3��6F   .+�5      �� $��Difficulty: Hard��6   $��0,6,0,0q�60   $��21(�6B   $	��140��6P   
���\\��$��Calibri Bold)�6s    �� TextAlignment$ Center=�6�   
������ 6�   �� 5      $��Time: 2 Hours��6   $��0,6,0,0q�6.   $��22(�6?   $	��140��6M   $ Center=�6Y   $��Calibri Bold)�6p   
��� ���
������ 6�   5      �� 5   
   -   5         ��Name$
 turk��5      $
��Left=�6   $	��266��69   $��
131,76,0,0q�6F   $	��Top=�6Z   $	��401��6r   $��
turkey.jpg��6~   $ 0.654,0.487&�6�   �� 5   
   -   5         ��Name$ 	Annotate1��5   %   $��	Add Notes��6   $��20(�68   $
��Left=�6F   $��
407,12,0,0q�6a   $	��Top=�6u   $	��140��6�   $��2��6�   $��39��6�   �� 5   
   -   5        $��noteRec��5      
���   � J� Opacity$	 0.3Q�60   $��526,75,-122,110q�6>   $��2��6W   $y�Hidden=�6d   �� 5   
   -   5        	 ��Name$	 Notes��5   �   
������ 
 �� TextWrapping$

 Wrap=�6,    �� AcceptsReturn . $	��271��6U   $
��Left=�6b   $��538,75,-122,0q�6}   $	��Top=�6�   $	��256��6�   $y�Hidden=�6�   $��2��6�   $��Calibri Bold)�6�   
�������$��16(�6  
������ 6(  c� 5   
   $
��Left=�6   $	��Top=�6-   $��41��6E   $��-206,0,-146,0q�6Q   $
��1024��6h   
���   �$	 0.3Q�6�   5      �� 5   
   -   5        $
��SAVE��5      $��40��6    
�������
�������$��688,1,-146,331q�6U   $	��130��6m   $��25(�6y   $��Calibri Bold)�6�   6�   �� 5   
   -	   5        $
��BACK��5      $��40��6    
�������
�������$��-192,1,734,331q�6U   $	��130��6m   $��25(�6y   $��Calibri Bold)�6�   6�   �� 5    
   $!��Roasted Thanksgiving Turkey��6   $ Center=�67   $��33(�6N   $��Calibri Bold)�6\   
�������$	 1.0Q�6�   $��65,-1,140,14q�6�   $��2��6�   �� 5!   
   
���   �$ .3Q�6!   $��-13,75,163,110q�6.   $��2��6F   �� 5"   
   -
   5         ��Name$ scrollViewer1��5"      $��Hidden=�6.   $��Disabled=�6S   $��0,75,163,110q�6|   $��2��6�   .��5#      � -   5         �Name$
 grid��5#      $	��865��6!   $	��377��6-   $ 0.5,0.5&�6:   .+�5$      (� $��0��6   $��0��6*   $��0,-1,20,-126q�67   .��5%      �� -   5        $��Recipe��5%   "   $��0q�60   $ Vertical=�6;   $	��982��6R   $	��514��6^   $y�Visible=�6k   .+�5&      �� -   5        $��	recipeBox��5&   g   $A��;1. Wash the potatoes and carrots in cold water until clean.��6$   $��23(�5'   $   
�������$��Calibri Bold)�6J   �� 5(      -   5        $��
recipeBox1��5(   ,   $�� ��6$   $��15(�5)   $   �� 5*      -   5        $��
recipeBox2��5*   e   $?��92. Using your hand pull out the heart, gizzard and liver.��6$   $��23(�5+   $   
�������$��Calibri Bold)�6J   �� 5,      -   5        $��
recipeBox3��5,   ,   $�� ��6$   $��15(�5-   $   �� 5.      -   5        $��
recipeBox4��5.   a   $;��53. Microwave the butter for 1 minute in a glass bowl.��6$   $��23(�5/   $   
�������$��Calibri Bold)�6J   �� 50      -   5        $��
recipeBox5��50   ,   $�� ��6$   $��15(�51   $   �� 52      -   5        $��
recipeBox6��52   g   $A��;4. Once the butter cools pour it over the turkey and rub it��6$   $��23(�53   $   
�������$��Calibri Bold)�6J   �� 54      -   5        $��
recipeBox7��54   ;   $��into the flesh.��6$   $��23(�55   $   
�������$��Calibri Bold)�6J   �� 56      -   5        $��
recipeBox8��56   ,   $�� ��6$   $��15(�57   $   �� 58      -   5        $��
recipeBox9��58   ^   $8��25. Stuff the turkey with the potatoes and carrots.��6$   $��23(�59   $   
�������$��Calibri Bold)�6J   �� 5:      -   5        $��recipeBox10��5:   ,   $�� ��6$   $��15(�5;   $   �� 5<      -   5        $��recipeBox11��5<   X   $2��,6. Sprinkle Salt and pepper over the turkey.��6$   $��23(�5=   $   
�������$��Calibri Bold)�6J   �� 5>      -   5        $��recipeBox12��5>   ,   $�� ��6$   $��15(�5?   $   �� 5@      -   5        $��recipeBox13��5@   h   $B��<7. Palce the turkey into the oven for 1 hour and 30 minutes.��6$   $��23(�5A   $   
�������$��Calibri Bold)�6J   �� 5B      -   5        $��ingredientBox��5B   :   $��1 Large Turkey��6$   $��23(�5C   $   
�������$��Calibri Bold)�6J   $y�Hidden=�6d   �� 5D      -   5        $��ingredientBox1��5D   ;   $��3 Large Potatos��6$   $��23(�5E   $   
�������$��Calibri Bold)�6J   $y�Hidden=�6d   �� 5F      -   5        $��ingredientBox2��5F   @   $��1 tablespoon of salt��6$   $��23(�5G   $   
�������$��Calibri Bold)�6J   $y�Hidden=�6d   �� 5H      -   5        $��ingredientBox3��5H   B   $��1 tablespoon of pepper��6$   $��23(�5I   $   
�������$��Calibri Bold)�6J   $y�Hidden=�6d   �� 5J      -   5        $��ingredientBox4��5J   =   $��1/2 cup of butter��6$   $��23(�5K   $   
�������$��Calibri Bold)�6J   $y�Hidden=�6d   �� 5L      -    5        $��	reviewBox��5L   <   $��This was amazing��6$   $��23(�5M   $   
�������$��Calibri Bold)�6J   $y�Hidden=�6d   5N      5P      5Q      5R      '  !RatingControlSample.RatingControl  5S   
   $
��Left=�6,   $��381,357,0,0q�6G   $	��Top=�6\   $	��118��6t   $��2��6�   5T      5U      