using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_culler : MonoBehaviour
{
    public ComputeShader cs;
    private ComputeBuffer cb;
    private int[] data;
    
    // Start is called before the first frame update
    void Start()
    {
        cb = new ComputeBuffer(64, 4);// int
        data = new int[64];
        
        
        int kernelID = cs.FindKernel("groupTest");
        cs.SetBuffer(kernelID,"outBuffer",cb);
        cs.Dispatch(kernelID,2,1,1);
        cb.GetData(data);

        for (int i = 0; i < 64; i++)
        {
            Debug.Log(data[i]);
        }
        
        cb.Release();
    }

    // Update is called once per frame
    void Update()
    {
       

    }
}
