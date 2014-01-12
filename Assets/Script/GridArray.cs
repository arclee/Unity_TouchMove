
using System;
using System.Collections.Generic;


//格子2維陣列.
/*
 * 正常使用流程:
 * //1 建立物件
 * GridArray gridar = new GridArray(8, 8);
 * //2.加入格子的種類編號.
 * gridar.AddGridType(0);
 * gridar.AddGridType(2);
 * gridar.AddGridType(5);
 * //3.初始化, 產生亂數種類到格子裡.
 * gridar.InitalGrid();
 * 
 * //接下來是操作.
 * 
 * //1.移動交換格子.(內部會自動設定它們為已動過.)
 * gridar.SwapGrid(0, 0, 0, 1);
 * //2.檢查移過動的格子有沒有造成相鄰的消除. 
 * gridar.ScanMovedGridToErase();  
 * //3.把要消除格子往上移,沒有要消除的格子往下移動. 可再接 3.
 * gridar.EraseGrid();
 * //4.產生替代要消除的格子.(內部會自動設定它們為已動過.) 可再接 3.
 * gridar.FillEraseRandGrid();
 
 
 
 
 */
class GridArray
{
    //陣列大小.
    private int DimX = 1;
    private int DimY = 1;

    //主格子陣列.
    /*
    v=整數
     
      v   v   v
      v   v   v   
      v   v   v   
      v   v   v   
     
     
     */
    private int[,] array;

    //要刪除的格子
    private bool[,] erasearray;

    //檢查過的格子
    private bool[,] checkedarray;

    //有動過的格子.
    private bool[,] movedarray;

    //格子的種類.
    List<int> GridTypes = new List<int>();

    //亂數.
    Random ran = new Random(Guid.NewGuid().GetHashCode());


    //記錄群組.
    public GridArray(int dimx, int dimy)
    {
        DimX = dimx;
        DimY = dimy;

        array = new int[DimX, DimY];
        checkedarray = new bool[DimX, DimY];
        erasearray = new bool[DimX, DimY];
        movedarray = new bool[DimX, DimY];
    }

    public void AddGridType(int value)
    {
        if (!GridTypes.Contains(value))
        {
            GridTypes.Add(value);
        }
    }

    public void ClearGridAllType()
    {
        GridTypes.Clear();
    }

    int GetRandGrid()
    {
        int gridcount = GridTypes.Count;
        return ran.Next(0, gridcount);    
    }

    public int GetGridValue(int x, int y)
    {
        if (x < 0 || x >=DimX || y < 0 || y >= DimY)
        {
            return -1;
        }

        return array[x, y];

    }
    public bool GetEraseValue(int x, int y)
    {
        if (x < 0 || x >= DimX || y < 0 || y >= DimY)
        {
            return false;
        }

        return erasearray[x, y];

    }
    public bool GetMovedValue(int x, int y)
    {
        if (x < 0 || x >= DimX || y < 0 || y >= DimY)
        {
            return false;
        }

        return movedarray[x, y];
    }

    public int GetEraseCount()
    {
        int count = 0;
        for (int x = 0; x < DimX; x++)
        {
            for (int y = 0; y < DimY; y++)
            {
                if (erasearray[x, y])
                {
                    count++;
                }
            }
        }

        return count;    
    }

    public void InitalGrid()
    {
        for (int x = 0; x < DimX; x++)
        {
            for (int y = 0; y < DimY; y++)
            {
                //亂數種類.
                array[x, y] = GetRandGrid();
            }
        }   
    }

    public void ClearAllFlag()
    {
        Array.Clear(checkedarray, 0, checkedarray.Length);
        Array.Clear(movedarray, 0, movedarray.Length);
        Array.Clear(erasearray, 0, erasearray.Length);
    }

    public void ClearCheckdFlag()
    {
        Array.Clear(checkedarray, 0, checkedarray.Length);
    }

    public void ClearMovedFlag()
    {
        Array.Clear(movedarray, 0, movedarray.Length);
    }
    public void ClearEraseFlag()
    {
        Array.Clear(erasearray, 0, erasearray.Length);
    }
    //交換格子.
    //接下來要呼叫 ScanMovedGridToErase.
    public void SwapGrid(int sx, int sy, int tx, int ty)
    {
        int tmp = array[tx, ty];
        array[tx, ty] = array[sx, sy];
        array[sx, sy] = tmp;
        
        bool ertmp = erasearray[tx, ty];
        erasearray[tx, ty] = erasearray[sx, sy];
        erasearray[sx, sy] = ertmp;

        //記錄有動過的格子.
        movedarray[sx, sy] = true;
        movedarray[tx, ty] = true;


    }

    public int ScanAlgorithm(int posx, int posy, int value, bool erase)
    {
        int count = 0;
        //是否檢查過.
        if (!checkedarray[posx, posy])
        {
            //取出值.
            int myValue = array[posx, posy];

            //標為已檢查.
            checkedarray[posx, posy] = true;

            //同色.
            if (myValue != -1 && myValue == value)
            {
                //設定是否刪除.
                erasearray[posx, posy] = erase;
                //計數加1.
                count++;
                count += ScanAlgorithmNeighborhood(posx, posy, value, erase);
            }
        }

        return count;
    }

    public int ScanAlgorithmNeighborhood(int posx, int posy, int value, bool erase)
    {
        int up = posy + 1;
        int down = posy - 1;
        int left = posx - 1;
        int right = posx + 1;

        int count = 0;

        //防止出界.
        if (up < DimY)
        {
            count += ScanAlgorithm(posx, up, value, erase);
        }

        if (down >= 0)
        {
            count += ScanAlgorithm(posx, down, value, erase);
        }

        if (left >= 0)
        {
            count += ScanAlgorithm(left, posy, value, erase);
        }

        if (right < DimX)
        {
            count += ScanAlgorithm(right, posy, value, erase);
        }

        return count;
    }

    //由有動過的位置開始展開消除.
    public void ScanMovedGridToErase()
    {
        //由有動過的位置開始展開消除.
        for (int x = 0; x < DimX; x++)
        {
            for (int y = 0; y < DimY; y++)
            {
                if (movedarray[x, y])
                {
                    //每個色塊都要清除檢查flag. 重檢查.
                    ClearCheckdFlag();
                    //目前這格.
                    int value = array[x, y];
                    //展開找.標成刪除.
                    int count = ScanAlgorithm(x, y, value, true);

                    //小於3個, 再標回不刪除.
                    if (count < 3)
                    {
                        //清除檢查flag.
                        ClearCheckdFlag();
                        ScanAlgorithm(x, y, value, false);
                    }

                    //順手清為未移動過.
                    movedarray[x, y] = false;   
                    //Console.Write("\n " + value.ToString()+" count=" + count.ToString() + "\n");
                }
            }
        }
    }

    //刪除被標記為 erasearray 裡的格子.
    //上面沒要刪除的的格子往下移.
    public void EraseGrid()
    {
        for (int x = 0; x < DimX; x++)
        {
            for (int y = 0; y < DimY; y++)
            {
                //順手清為未移動過.
                //movedarray[x, y] = false;
                //找沒要刪除的.
                if (!erasearray[x, y])
                {
                    int nowx = x;
                    int nowy = y;
                    //往前找要消除的, 交換位置.
                    for (int z = y; z >= 0; z--)
                    {
                        //要消除的
                        if (erasearray[x, z])
                        {
                            array[x, z] = -1;
                            SwapGrid(nowx, nowy, x, z);
                            nowx = x;
                            nowy = z;
                        }
                    }
                }
            }
        }   
    }

    public void EraseGrid2()
    {
        //刪除.
        //補格.
        //移動.
    }
    //把要刪除的塡入新值.
    public void FillEraseRandGrid()
    {
        //找出要刪除的.
        for (int x = 0; x < DimX; x++)
        {
            for (int y = 0; y < DimY; y++)
            {
                if (erasearray[x, y])
                {
                    //補上新的值.
                    array[x, y] = GetRandGrid();
                    //標記成移動過的.
                    movedarray[x, y] = true;
                }
                else
                {
                    //順手清為未移動過.
                    //movedarray[x, y] = false;                
                }
            }
        }    
    }

    public void DebugPringArray()
    {
        Console.Write("array  \n");
        for (int y = DimY - 1; y >= 0; y--)
        {
            for (int x = 0; x < DimX; x++)
            {
                Console.Write(array[x, y].ToString());
                Console.Write("\t");
            }
            Console.Write("\n");
        }
    }

    public void DebugPringChecked()
    {

        Console.Write("checkedarray  \n");
        for (int y = DimY - 1; y >= 0; y--)
        {
            for (int x = 0; x < DimX; x++)
            {
                if (checkedarray[x, y])
                {
                    Console.Write("1");
                }
                else
                {
                    Console.Write("0");                
                }
                Console.Write("\t");
            }
            Console.Write("\n");
        }

    }

    public void DebugPringErase()
    {
        Console.Write("erasearray  \n");
        for (int y = DimY - 1; y >= 0; y--)
        {
            for (int x = 0; x < DimX; x++)
            {
                if (erasearray[x, y])
                {
                    Console.Write("1");
                }
                else
                {
                    Console.Write("0");
                }
                Console.Write("\t");
            }
            Console.Write("\n");
        }
    }
};