using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TestProtobuf : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        /*ProtoBuf序列化
        User user = new User();
        user.ID = 100;
        user.Username = "siki";
        user.Password = "123456";
        user.Level = 100;
        user._UserType = User.UserType.Master;

        //FileStream fs = File.Create(Application.dataPath + "/user.bin");
        //Serializer.Serialize<User>(fs, user);
        //fs.Close();

        using (var fs = File.Create(Application.dataPath + "/user.bin"))
        {
            Serializer.Serialize<User>(fs, user);
        }
        */

        /*ProtoBuf反序列化
        User user = null;
        using (var fs = File.OpenRead(Application.dataPath + "/user.bin"))
        {
            user=Serializer.Deserialize<User>(fs);
        }
        print(user.ID);
        print(user.Level);
        print(user.Password);
        print(user.Username);
        print(user._UserType);
        */
    }

    // Update is called once per frame
    void Update()
    {

    }
}
