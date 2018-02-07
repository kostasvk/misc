//Konstantinos V. 2018
import java.io.*;
import java.util.*;
import java.text.*;
import java.math.*;
import java.util.regex.*;

public class Solution {
    static int [] perimeter(int levels, int rows, int columns){
        int [] perim = new int[levels];
        for(int i =0;i<levels;i++){
            perim[i]=2*(rows-i*2)+((columns-i*2)-2)*2;
        }
        return perim;
    }
    
    static int [][] rotate(int [][] matrix, int level, int actual_rot, int perim){
        int maxX=matrix.length-(1+level);
        int maxY=matrix[0].length-(1+level);
        int minX=level;
        int minY=level;
        int i = level;
        int j = level;
        int prev=matrix[level][level];
        int temp;
        for(int spin=0;spin<actual_rot;spin++){
            for(int count = 0; count <= perim; count++){           
                if(j==minY){
                    if(i!=maxX){
                        i++;
                    }else{
                        j++;
                    }
                }else if(j==maxY){
                    if(i!=minX){
                        i--;
                    }else{
                        j--;
                    }
                }else if(i==maxX){
                    j++;
                }else if(i==minX){
                    j--;
                }
                temp=matrix[i][j];
                matrix[i][j]=prev;
                prev=temp;
            }
            
        }
        return matrix;
    }
    
    static int[][] matrixRotation(int[][] matrix, long rot) {
        int rows=matrix.length;
        int columns = matrix[0].length;
        int levels = (rows<=columns? rows:columns)/2;
        int [] perimeters = new int[levels];
        perimeters = perimeter(levels, rows, columns);
        for(int i=0;i<levels;i++){
           int actual_rot = (int)rot%(perimeters[i]);
            matrix=rotate(matrix, i, actual_rot, perimeters[i]);
        }
        return matrix;
    }

    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        int m = in.nextInt();
        int n = in.nextInt();
        long r = in.nextLong();
        int[][] matrix = new int[m][n];
        for(int matrix_i = 0; matrix_i < m; matrix_i++){
            for(int matrix_j = 0; matrix_j < n; matrix_j++){
                matrix[matrix_i][matrix_j] = in.nextInt();
            }
        }
        matrix= matrixRotation(matrix,r);
        for(int matrix_i = 0; matrix_i < m; matrix_i++){
            for(int matrix_j = 0; matrix_j < n; matrix_j++){
                System.out.print(matrix[matrix_i][matrix_j]+" ");
            }
            System.out.print("\n");
        }
        in.close();
    }
}
