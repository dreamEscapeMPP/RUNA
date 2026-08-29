# RUNA : 소녀가 악몽에서 탈출하는 2D 추리 탈출 게임
<br>

<br>
소녀가 잊어버린 토끼인형이 자신을 기억해 달라며 꿈에 나타나 추억을 기억하게 하는 방탈출 게임
<br>진행기간 2023/02/12 - 2023/03/26
<br><img src="https://img.shields.io/badge/Unity-000000?style=for-the-badge&logo=Unity&logoColor=white">

![그림02](https://github.com/user-attachments/assets/b53c4fec-f023-474f-9024-ca337a513a69)

게임 링크 : https://play.google.com/store/apps/details?id=com.companyname.RUNA

<br>

## 개발자 참고 사항

### 개발 환경
- Unity **6000.3.13f1** (Unity 6.3) — 2026-08 업그레이드 (기존 2020.3.32f1)
- Android targetSdk 36 / minSdk는 ProjectSettings 참고
- 프로젝트 경로에 **한글이 포함되면 Android 빌드가 실패**합니다 (예: `바탕화면`). `D:\Runa` 처럼 영문 경로에 클론하세요.

### 릴리스 서명용 키스토어 설정 (필수)
키스토어와 비밀번호는 보안상 저장소에 **포함되어 있지 않습니다** (`.gitignore` 처리). 릴리스 빌드를 하려면 아래 두 파일을 직접 준비해야 합니다.

1. **`foxes.keystore`** — 팀 담당자에게 받아서 **프로젝트 루트**(`Assets` 폴더와 같은 위치)에 넣습니다.
   - 하위 폴더(예: `Keys/foxes.keystore`)에 넣어도 자동으로 찾습니다.
2. **`Assets/Editor/LocalKeystorePassword.cs`** — 아래 내용으로 직접 생성하고, `<비밀번호>` 부분을 담당자에게 받은 값으로 채웁니다. 이 파일은 `.gitignore` 되어 있으므로 커밋되지 않습니다.

```csharp
// 로컬 전용: 키스토어 경로·비밀번호를 에디터 로드 시 주입한다. 절대 커밋하지 않는다.
using System.IO;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class LocalKeystorePassword
{
    const string KeystoreFileName = "foxes.keystore";
    const string KeystorePass = "<키스토어 비밀번호>";
    const string KeyAlias = "foxes";
    const string KeyAliasPass = "<alias 비밀번호>";

    static LocalKeystorePassword()
    {
        string projectRoot = Path.GetFullPath(Path.Combine(Application.dataPath, ".."));
        string found = FindKeystore(projectRoot);
        if (found == null)
        {
            Debug.LogWarning($"[LocalKeystorePassword] '{KeystoreFileName}' 을(를) 프로젝트 폴더({projectRoot}) 하위에서 찾지 못했습니다.");
            return;
        }
        string relative = found.Substring(projectRoot.Length).TrimStart('\', '/').Replace('\', '/');
        PlayerSettings.Android.useCustomKeystore = true;
        PlayerSettings.Android.keystoreName = relative;
        PlayerSettings.Android.keystorePass = KeystorePass;
        PlayerSettings.Android.keyaliasName = KeyAlias;
        PlayerSettings.Android.keyaliasPass = KeyAliasPass;
    }

    static string FindKeystore(string root)
    {
        string direct = Path.Combine(root, KeystoreFileName);
        if (File.Exists(direct)) return direct;
        string[] skip = { "Library", "Temp", "Logs", "obj", "Build", "Builds", ".git", ".utmp", "UserSettings" };
        foreach (string dir in Directory.GetDirectories(root))
        {
            if (System.Array.IndexOf(skip, Path.GetFileName(dir)) >= 0) continue;
            try
            {
                string[] hits = Directory.GetFiles(dir, KeystoreFileName, SearchOption.AllDirectories);
                if (hits.Length > 0) return hits[0];
            }
            catch (System.Exception) { }
        }
        return null;
    }
}
```

에디터를 열면 스크립트가 키스토어를 찾아 `Player Settings > Publishing Settings`에 자동으로 채워 줍니다. 콘솔에 `[LocalKeystorePassword]` 경고가 뜨면 키스토어 파일 위치를 확인하세요.

> ⚠️ 키스토어 파일과 비밀번호는 **절대 커밋하거나 공개 채널에 올리지 마세요.** 분실하면 스토어에 앱 업데이트를 올릴 수 없습니다.
